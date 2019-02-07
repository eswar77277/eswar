const mongoose = require('mongoose');

//users,posts,products

const PostSchema = new mongoose.Schema({
    tittle : String,
    description :String
    ,
    content:String
})


const Post = mongoose.model('Post' , PostSchema);


module.exports=Post;