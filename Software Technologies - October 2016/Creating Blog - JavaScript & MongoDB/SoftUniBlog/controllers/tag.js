const Article = require('mongoose').model('Article');
const Tag = require('mongoose').model('Tag');

module.exports = {
    listArticlesByTag: function (req, res) {
        let name = req.params.name;

        Tag.findOne({name: name}).then(tag => {
            Article.find({tags: tag.id}).populate('author tags').then(articles => {

                for (let article of articles) {
                    article.summary = article.content.substring(0, 500) + "...";
                }

                res.render('tag/details', {articles: articles, tag: tag});
            })
        })
    }
};