<template>
	<v-container class="header">
		<v-row>
			<a href="https://provisa.kz/" class="linkToMainSite">Pro Visa</a>
		</v-row>
	</v-container>
</template>

<script>
export default {

}
</script>

<style lang="scss">
.header {
	.linkToMainSite {
		color: white;
		font-size: 26px;
		font-family: 'Pacifico', cursive;
		text-decoration: none;
		transition: .1s;
		&:hover {
			text-decoration: none;
			font-size: 27px;
		}
	}
}
</style>