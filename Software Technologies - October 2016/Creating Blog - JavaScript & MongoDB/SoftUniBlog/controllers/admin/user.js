const User = require('mongoose').model('User');
const Role = require('mongoose').model('Role');
const encryption = require('./../../utilities/encryption');

module.exports = {
    all: function (req, res) {
        User.find({}).then(users => {

            for (let user of users) {
                user.isInRole('Admin').then(isAdmin => {
                    user.isAdmin = isAdmin;
                });
            }

            res.render('admin/user/all', {users: users})
        });
    },

    editGet: function (req, res) {
        let id = req.params.id;

        User.findById(id).then(user => {
            Role.find({}).then(roles => {
                for (let role of roles) {
                    if (user.roles.indexOf(role.id) !== -1) {
                        role.isChecked = true;
                    }
                }

                res.render('admin/user/edit', {user: user, roles: roles});
            });
        })
    },

    editPost: function (req, res) {
        let id = req.params.id;
        let userArgs = req.body;

        User.findOne({email: userArgs.email, _id: {$ne: id}}).then(otherUser => {
            let errorMessage = '';
            if (otherUser) {
                errorMessage = 'User with the same username exists!';
            } else if (!userArgs.email) {
                errorMessage = 'Email cannot be empty!';
            } else if (!userArgs.fullName) {
                errorMessage = 'Name cannot be empty!';
            } else if (userArgs.password !== userArgs.confirmedPassword) {
                errorMessage = 'Passwords do no match!';
            }

            if (errorMessage) {
                userArgs.error = errorMessage;
                res.render('/admin/user/edit', userArgs);
            } else {
                User.findOne({_id: id}).then(user => {
                    user.email = userArgs.email;
                    user.fullName = userArgs.fullName;

                    let passwordHash = user.passwordHash;
                    if (userArgs.password) {
                        passwordHash = encryption.hashPassword(userArgs.password, user.salt);
                    }

                    user.passwordHash = passwordHash;

                    Role.find({}).then(roles => {
                        if (!userArgs.roles) {
                            roles = [];
                        }

                        let oldRoles = roles.filter(role => {
                            return user.roles.indexOf(role.id) !== -1
                        });

                        for (let role of oldRoles) {
                            if (role.users.indexOf(id) !== -1) {
                                role.users.remove(user.id);
                                role.save();
                            }
                        }

                        let newRoles = roles.filter(role => {
                            return userArgs.roles.indexOf(role.name) !== -1
                        });

                        for (let role of newRoles) {
                            if (role.users.indexOf(id) === -1) {
                                role.users.push(user.id);
                                role.save();
                            }
                        }

                        let newUserRoles = newRoles.map(role => {
                            return role.id
                        });

                        user.roles = newUserRoles;

                        user.save((err) => {
                            if (err) {
                                res.redirect('/');
                            } else {
                                res.redirect('/admin/user/all')
                            }
                        })
                    })
                })
            }
        })
    },

    deleteGet: function (req, res) {
        let id = req.params.id;
        User.findById(id).then(user => {
            res.render('admin/user/delete', {userToDelete: user})
        });
    },

    deletePost: function (req, res) {
        let id = req.params.id;

        User.findOneAndRemove({_id: id}).then(user => {
            user.prepareToDelete();
            res.redirect('/admin/user/all');
        })
    }
};