const Category = require('mongoose').model('Category');

module.exports = {
    all: function (req, res) {
        Category.find({}).then(categories => {
            res.render('admin/category/all', {categories: categories});
        });
    },

    createGet: function (req, res) {
        res.render('admin/category/create');
    },

    createPost: function (req, res) {
        let categoryArgs = req.body;

        if (!categoryArgs.name) {
            let errorMessage = 'Category name cannot be empty!';
            categoryArgs.error = errorMessage;
            res.render('admin/category/create', categoryArgs);
        } else {
            Category.create(categoryArgs).then(category => {
                res.redirect('/admin/category/all');
            });
        }
    },

    editGet: function (req, res) {
        let id = req.params.id;

        Category.findById(id).then(category => {
            res.render('admin/category/edit', {category: category})
        });
    },

    editPost: function (req, res) {
        let id = req.params.id;

        let editArgs = req.body;

        if (!editArgs.name) {
            let errorMessage = 'Category name cannot be empty!';

            Category.findById(id).then(category => {
                res.render('admin/category/edit', {category: category, error: errorMessage});
            });
        } else {
            Category.findOneAndUpdate({_id: id}, {name: editArgs.name}).then(category => {
                res.redirect('/admin/category/all');
            });
        }
    },

    deleteGet: function (req, res) {
        let id = req.params.id;

        Category.findById(id).then(category => {
            res.render('admin/category/delete', {category: category})
        });
    },

    deletePost: function (req, res) {
        let id = req.params.id;

        Category.findOneAndRemove({_id: id}).then(category => {
            category.prepareToDelete();
            res.redirect('/admin/category/all');
        });
    }
};