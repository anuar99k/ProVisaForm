<template>
	<v-app>
		<v-app-bar app color="green accent-3">
			<Header />
		</v-app-bar>

		<v-main class="main">
			<router-view />
		</v-main>

		<Footer />
	</v-app>
</template>

<script>
import Header from '@/components/public/Header';
import Footer from '@/components/public/Footer';

export default {
	name: 'App',

	components: {
		Header, Footer
	}
};
</script>

<style lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Pacifico&family=Pattaya&family=Roboto+Condensed:wght@400;700&family=Rubik&display=swap');

// .main {
// 	background: url("./assets/images/New-York-City-Backgr.jpg") no-repeat center fixed;
// 	background-size: cover;
// 	.imageCover {
// 		height: 100vh;
// 		width: 100%;
// 		position: absolute;
// 		background-image: -webkit-linear-gradient(top, rgba(0,0,0,0.70), rgba(0,0,0,0.70));
// 	}
// 	.content {
// 		position: relative;
// 	}
// }

html, body, #app {
	/* font-family: 'Pacifico', cursive;
	font-family: 'Pattaya', sans-serif;
	font-family: 'Roboto Condensed', sans-serif;
	font-family: 'Rubik', sans-serif; */
}
</style>