import axios from '../axios/index.js';

export default {
    // getArticleById(resolve, reject, articleId) {
    //     axios.get(`api/articles/id/${articleId}`)
    //         .then(response => resolve(response.data))
    //         .catch(error => reject(error.response));
    // },
	// getAllArticles(resolve, reject) {
    //     axios.get(`api/articles`)
    //         .then(response => resolve(response.data))
    //         .catch(error => reject(error.response));
    // },
    addApplication(resolve, reject, data) {
        axios.post("api/applications", data)
            .then(response => resolve(response.data))
            .catch(error => reject(error.response));
    },
    // deleteArticle(resolve, reject, id) {
    //     axios.delete(`api/drugs/${id}`)
    //         .then(response => resolve(response.data))
    //         .catch(error => reject(error.response));
    // },
}