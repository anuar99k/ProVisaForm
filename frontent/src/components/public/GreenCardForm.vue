<template>
	<v-form>
	<v-container class="greenCardForm">
			<v-row class="mt-6 mb-7">
				<span class="mainTitle">
					Анкета на участие в лотерее <span class="green--text text--accent-3">GREEN CARD</span>
				</span>
			</v-row>

			<v-card class="card personalDataCard mx-n3">
				<v-container fluid class="pa-0">
					<v-row dark class="black py-5 px-16 ma-0 mb-5 cardTitle">
						<span>Личные данные</span>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Фамилия</span>
							<v-text-field v-model="lastName" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Имя</span>
							<v-text-field v-model="firstName" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Last name (латинскими буквами)</span>
							<v-text-field v-model="lastNameLatin" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">First name (латинскими буквами)</span>
							<v-text-field v-model="firstNameLatin" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Страна рождения</span>
							<v-text-field v-model="birthCountry" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Место рождения</span>
							<v-text-field v-model="birthCity" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Дата рождения</span>
							<v-menu ref="birthDateMenu" v-model="birthDateMenu" :close-on-content-click="false" 
									transition="scale-transition" offset-y min-width="auto">
								<template v-slot:activator="{ on, attrs }">
									<v-text-field v-model="birthDateFormatted" readonly v-bind="attrs" v-on="on"
												class="input pt-0" color="black" clearable required :rules="requiredRule"></v-text-field>
								</template>
								<v-date-picker v-model="birthDate" :active-picker.sync="activePicker" 
									@input="FormatDateAndCloseMenu(birthDate, 'birthDate')"
									:max="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
									min="1940-01-01" color="green accent-3" locale="ru-RU" first-day-of-week="1"></v-date-picker>
							</v-menu>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Полное оконченное образование</span>
							<v-select :items="completedEducationItems" v-model="completedEducation" class="completedEducation"
									clearable color="black" item-color="black" dense required :rules="requiredRule"></v-select>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Телефон</span>
							<v-text-field v-model="phoneNumber" clearable color="black" :rules="phoneNumberRules"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Email</span>
							<v-text-field v-model="email" clearable color="black" :rules="emailRules"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Ваш адрес</span>
								<v-textarea outlined v-model="address" class="input pt-2" rows="2" color="black"
									placeholder="050000, Алматинская область, г. Алматы, ул. Абая, д. 1, кв. 123">
								</v-textarea>
						</v-col>
					</v-row>
				</v-container>
			</v-card>

			<v-card class="card passportDataCard mx-n3 mt-16">
				<v-container fluid class="pa-0">
					<v-row dark class="black py-5 px-16 ma-0 mb-5 cardTitle">
						<span>Паспортные данные (латинскими буквами)</span>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Серия* и номер паспорта</span>
							<v-text-field v-model="passportSeriesAndNumber" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Страна выдачи паспорта</span>
							<v-text-field v-model="passportСountryIssuer" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Паспорт действителен до</span>
							<v-menu ref="passportValidDateMenu" v-model="passportValidDateMenu" :close-on-content-click="false" 
									transition="scale-transition" offset-y min-width="auto">
								<template v-slot:activator="{ on, attrs }">
									<v-text-field v-model="passportValidDateFormatted" readonly v-bind="attrs" v-on="on"
												class="input pt-0" color="black" clearable required :rules="requiredRule"></v-text-field>
								</template>
								<v-date-picker v-model="passportValidDate" :active-picker.sync="activePicker" 
									@input="FormatDateAndCloseMenu(passportValidDate, 'passportValidDate')"
									min="1940-01-01" color="green accent-3" locale="ru-RU" first-day-of-week="1"></v-date-picker>
							</v-menu>
						</v-col>
					</v-row>
					<v-row class="px-16 mt-0">
						<v-col>
							<span class="grey--text text--darken-2">
								* Серия паспорта заполняется на английском языке. При наличии загранпаспорта данные берутся оттуда.
							</span>
						</v-col>
					</v-row>
				</v-container>
			</v-card>

			<v-card class="card photoCard mx-n3 mt-16">
				<v-container fluid class="pa-0">
					<v-row dark class="black py-5 px-16 ma-0 mb-5 cardTitle">
						<span>Ваша фотография</span>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12">
							<v-img src="@/assets/images/form_photo_help.jpg"></v-img>
						</v-col>
						<v-col sm="6">
							<v-file-input accept="image/*" v-model="applicantPhoto" :rules="requiredRule"
								class="input pt-0" required validate-on-blur filled outlined dense
								placeholder="Добавить фото" prepend-icon="mdi-camera" color="black"></v-file-input>
						</v-col>
						<v-col cols="12" sm="6">
							<v-btn to="/photoRequirements" target="_blank" class="photoRequirementsLink"
								color="green accent-4" dark>
								<span>Требования к фото</span>
							</v-btn>
						</v-col>
					</v-row>
				</v-container>
			</v-card>

			<v-card class="card mx-n3 mt-16">
				<v-container fluid class="pa-0">
					<v-row dark class="black py-5 px-16 ma-0 mb-5 cardTitle">
						<span>Семья</span>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Семейное положение</span>
							<v-select :items="familyStatusItems" v-model="familyStatus" class="familiStatus"
									clearable color="black" item-color="black" dense required :rules="requiredRule"
									@change="ShowSpouseCardIfChosen()"></v-select>
						</v-col>
					</v-row>
				</v-container>
			</v-card>

			<v-card v-if="spouseCardIsVisible" class="card mx-n3 mt-16">
				<v-container fluid class="pa-0">
					<v-row dark class="black py-5 px-16 ma-0 mb-5 cardTitle spouseCardTitle justify-space-between">
						<span>Данные жены/мужа</span>
						<v-btn fab small text dark @click="HideSpouseCard()">
							<v-icon dark>mdi-close</v-icon>
						</v-btn>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">First name (латинскими буквами)</span>
							<v-text-field v-model="spouseFirstNameLatin" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Last name (латинскими буквами)</span>
							<v-text-field v-model="spouseLastNameLatin" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Страна рождения</span>
							<v-text-field v-model="spouseBirthCountry" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Место рождения</span>
							<v-text-field v-model="spouseBirthCity" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Дата рождения</span>
							<v-menu ref="spouseBirthDateMenu" v-model="spouseBirthDateMenu" :close-on-content-click="false" 
									transition="scale-transition" offset-y min-width="auto">
								<template v-slot:activator="{ on, attrs }">
									<v-text-field v-model="spouseBirthDateFormatted" readonly v-bind="attrs" v-on="on"
												class="input pt-0" color="black" clearable required :rules="requiredRule"></v-text-field>
								</template>
								<v-date-picker v-model="spouseBirthDate" :active-picker.sync="activePicker" 
									@input="FormatDateAndCloseMenu(spouseBirthDate, 'spouseBirthDate')"
									:max="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
									min="1940-01-01" color="green accent-3" locale="ru-RU" first-day-of-week="1"></v-date-picker>
							</v-menu>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Полное оконченное образование</span>
							<v-select :items="completedEducationItems" v-model="spouseCompletedEducation" class="completedEducation"
									clearable color="black" item-color="black" dense required :rules="requiredRule"></v-select>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Серия и номер паспорта</span>
							<v-text-field v-model="spousePassportSeriesAndNumber" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
						<v-col cols="12" sm="6">
							<span class="inputTitle">Страна выдачи паспорта</span>
							<v-text-field v-model="spousePassportСountryIssuer" clearable color="black" :rules="requiredRule"
								class="input pt-0" required validate-on-blur></v-text-field>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Паспорт действителен до</span>
							<v-menu ref="spousePassportValidDateMenu" v-model="spousePassportValidDateMenu" :close-on-content-click="false" 
									transition="scale-transition" offset-y min-width="auto">
								<template v-slot:activator="{ on, attrs }">
									<v-text-field v-model="spousePassportValidDateFormatted" readonly v-bind="attrs" v-on="on"
												class="input pt-0" color="black" clearable required :rules="requiredRule"></v-text-field>
								</template>
								<v-date-picker v-model="spousePassportValidDate" :active-picker.sync="activePicker" 
									@input="FormatDateAndCloseMenu(spousePassportValidDate, 'spousePassportValidDate')"
									min="1940-01-01" color="green accent-3" locale="ru-RU" first-day-of-week="1"></v-date-picker>
							</v-menu>
						</v-col>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12">
							<v-img src="@/assets/images/form_photo_help.jpg"></v-img>
						</v-col>
						<v-col cols="12" sm="6">
							<v-file-input accept="image/*" v-model="spousePhoto" :rules="requiredRule"
								class="input pt-0" required validate-on-blur filled outlined dense
								placeholder="Добавить фото" prepend-icon="mdi-camera" color="black"></v-file-input>
						</v-col>
						<v-col cols="12" sm="6">
							<v-btn to="/photoRequirements" target="_blank" class="photoRequirementsLink"
								color="green accent-4" dark>
								<span>Требования к фото</span>
							</v-btn>
						</v-col>
					</v-row>
				</v-container>
			</v-card>

			<v-card class="card mx-n3 mt-16">
				<v-container fluid class="pa-0">
					<v-row dark class="black py-5 px-16 ma-0 mb-5 cardTitle">
						<span>Дети</span>
					</v-row>
					<v-row class="px-16">
						<v-col cols="12" sm="6">
							<span class="inputTitle">Есть ли дети до 21 года?</span>
							<v-select :items="['Нет', 'Да']" v-model="hasChildren" @change="ShowChildCardIfYes()"
									clearable color="black" item-color="black" dense required :rules="requiredRule"></v-select>
						</v-col>
					</v-row>
				</v-container>
			</v-card>

			<div v-if="childrenCardsAreVisible">
				<v-card v-for="(child, index) in children" :key="index" class="card mx-n3 mt-16">
					<v-container fluid class="pa-0">
						<v-row dark class="black py-5 px-16 ma-0 mb-5 cardTitle justify-space-between">
							<span>Данные ребенка</span>
							<v-btn fab small text dark @click="RemoveChild(index)">
								<v-icon dark>mdi-close</v-icon>
							</v-btn>
						</v-row>
						<v-row class="px-16">
							<v-col cols="12" sm="6">
								<span class="inputTitle">First name (латинскими буквами)</span>
								<v-text-field v-model="child.firstNameLatin" clearable color="black" :rules="requiredRule"
									class="input pt-0" required validate-on-blur></v-text-field>
							</v-col>
							<v-col cols="12" sm="6">
								<span class="inputTitle">Last name (латинскими буквами)</span>
								<v-text-field v-model="child.lastNameLatin" clearable color="black" :rules="requiredRule"
									class="input pt-0" required validate-on-blur></v-text-field>
							</v-col>
						</v-row>
						<v-row class="px-16">
							<v-col cols="12" sm="6">
								<span class="inputTitle">Страна рождения</span>
								<v-text-field v-model="child.birthCountry" clearable color="black" :rules="requiredRule"
									class="input pt-0" required validate-on-blur></v-text-field>
							</v-col>
							<v-col cols="12" sm="6">
								<span class="inputTitle">Место рождения</span>
								<v-text-field v-model="child.birthCity" clearable color="black" :rules="requiredRule"
									class="input pt-0" required validate-on-blur></v-text-field>
							</v-col>
						</v-row>
						<v-row class="px-16">
							<v-col cols="12" sm="6">
								<span class="inputTitle">Дата рождения</span>
								<v-menu ref="childBirthDateMenu" v-model="child.birthDateMenu" :close-on-content-click="false" 
										transition="scale-transition" offset-y min-width="auto">
									<template v-slot:activator="{ on, attrs }">
										<v-text-field v-model="child.birthDateFormatted" readonly v-bind="attrs" v-on="on"
													class="input pt-0" color="black" clearable required :rules="requiredRule"></v-text-field>
									</template>
									<v-date-picker v-model="child.birthDate" :active-picker.sync="activePicker" 
										@input="FormatDateAndCloseChildMenu(child.birthDate, index)"
										:max="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
										min="1940-01-01" color="green accent-3" locale="ru-RU" first-day-of-week="1"></v-date-picker>
								</v-menu>
							</v-col>
						</v-row>
					</v-container>
				</v-card>
				<v-row class="justify-center" v-if="this.children.length != 0">
					<v-btn @click="AddChild()" class="addChildButton mt-10" color="primary" rounded dark large>
						<span>Добавить ребенка</span>
					</v-btn>
				</v-row>
			</div>

			<v-row class="justify-center my-10">
				<v-btn class="sendFormButton" color="green accent-4" rounded dark x-large>
					<span>Отправить анкету</span>
				</v-btn>
			</v-row>

			<!-- <v-card class="card mx-n3 mt-16">
				<v-container fluid class="pa-0">
					<v-row dark class="black py-5 px-16 ma-0 mb-5 cardTitle">
						<span>Отправка анкеты</span>
					</v-row>
					<v-row class="px-16">
						<v-col sm="6">
							<v-btn class="" color="green accent-4" rounded dark x-large>
								<span>Отправить анкету</span>
							</v-btn>
						</v-col>
					</v-row>
				</v-container>
			</v-card> -->
	</v-container>
	</v-form>
</template>

<script>
export default {
	data() {
		return {
			lastName: "",
			firstName: "",
			lastNameLatin: "",
			firstNameLatin: "",
			birthCountry: "",
			birthCity: "",
			birthDate: null,
			birthDateFormatted: null,
			activePicker: null,
			birthDateMenu: false,
			completedEducation: "",
			phoneNumber: "",
			email: "",
			address: "",
			passportSeriesAndNumber: "",
			passportСountryIssuer: "",
			passportValidDateMenu: false,
			passportValidDateFormatted: null,
			passportValidDate: null,
			applicantPhoto: null,
			familyStatus: "",
			spouseFirstNameLatin: "",
			spouseLastNameLatin: "",
			spouseBirthCountry: "",
			spouseBirthCity: "",
			spouseBirthDateMenu: false,
			spouseBirthDateFormatted: null,
			spouseBirthDate: null,
			spouseCompletedEducation: "",
			spousePassportSeriesAndNumber: "",
			spousePassportСountryIssuer: "",
			spousePassportValidDateMenu: false,
			spousePassportValidDateFormatted: null,
			spousePassportValidDate: null,
			spousePhoto: null,
			hasChildren: "",
			childrenCardsAreVisible: false,
			children: [
				{
					firstNameLatin: "",
					lastNameLatin: "",
					birthCountry: "",
					birthCity: "",
					birthDate: null,
					birthDateFormatted: null,
					photo: "",
					birthDateMenu: false
				}
			],

			spouseCardIsVisible: false,
			completedEducationItems: [
				"Высшее", "Среднее", "Средне-специальное после 8/9 кл.", "Средне-специальное после 10/11 кл."
			],
			familyStatusItems: [
				"Холост / Не замужем", "Женат / Замужем", "Разведен(а)", "Вдовец / Вдова"
			],
			requiredRule: [
				v => !!v || "Обязательное поле"
			],
			phoneNumberRules: [
				v => !!v || 'Введите телефон',
                v => /(\+7|8)[- _]*\(?[- _]*(\d{3}[- _]*\)?([- _]*\d){7}|\d\d[- _]*\d\d[- _]*\)?([- _]*\d){11})/g.test(v) || 'Некорректный ввод номера телефона'
			],
			emailRules: [
                v => !!v || 'Введите почту',
                v => /^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$/.test(v) || 'Некорректный ввод эл. почты',
            ],
		}
	},
	watch: {
		birthDateMenu(val) {
			val && setTimeout(() => (this.activePicker = 'YEAR'))
		},
		passportValidDateMenu(val) {
			val && setTimeout(() => (this.activePicker = 'YEAR'))
		},
		spouseBirthDateMenu(val) {
			val && setTimeout(() => (this.activePicker = 'YEAR'))
		},
		spousePassportValidDateMenu(val) {
			val && setTimeout(() => (this.activePicker = 'YEAR'))
		},
		childBirthDateMenu(val) {
			val && setTimeout(() => (this.activePicker = 'YEAR'))
		}
    },
	methods: {
		FormatDateAndCloseMenu(date, dateType) {
			const [year, month, day] = date.split('-');

			if (dateType == "birthDate") {
				this.birthDateFormatted = `${day}.${month}.${year}`;
				this.birthDateMenu = false;
			} else if (dateType == "passportValidDate") {
				this.passportValidDateFormatted = `${day}.${month}.${year}`;
				this.passportValidDateMenu = false;
			} else if (dateType == "spouseBirthDate") {
				this.spouseBirthDateFormatted = `${day}.${month}.${year}`;
				this.spouseBirthDateMenu = false;
			} else if (dateType == "spousePassportValidDate") {
				this.spousePassportValidDateFormatted = `${day}.${month}.${year}`;
				this.spousePassportValidDateMenu = false;
			}
		},
		FormatDateAndCloseChildMenu(date, index) {
			const [year, month, day] = date.split('-');

			this.children[index].birthDateFormatted = `${day}.${month}.${year}`;
			this.children[index].birthDateMenu = false;
		},
		ShowSpouseCardIfChosen() {
			if (this.familyStatus == "Женат / Замужем"){
				this.spouseCardIsVisible = true;
			} else {
				this.spouseCardIsVisible = false;
			}
		},
		HideSpouseCard() {
			this.familyStatus = "";
			this.spouseCardIsVisible = false;
		},
		ShowChildCardIfYes() {
			if (this.hasChildren == "Да") {
				this.childrenCardsAreVisible = true;
				
				if (this.children.length == 0) {
					this.AddChild();
				}
			} else {
				this.childrenCardsAreVisible = false;
			}
		},
		RemoveChild(index) {
			this.children.splice(index, 1);

			if (this.children.length == 0) {
				this.hasChildren = "";
			}
		},
		AddChild() {
			var child = {
				firstNameLatin: "",
				lastNameLatin: "",
				birthCountry: "",
				birthCity: "",
				birthDate: null,
				birthDateFormatted: null,
				photo: "",
				birthDateMenu: false
			}
			this.children.push(child);
		}
	}
}
</script>

<style lang="scss">
.greenCardForm {
	font-family: 'Rubik', sans-serif !important;
	font-family: 'Roboto Condensed', sans-serif !important;
	.mainTitle {
		font-family: 'Roboto Condensed', sans-serif !important;
		font-size: 36px !important;
		font-weight: 700;
	}
	.card {
		border-top-left-radius: 25px !important;
		border-top-right-radius: 25px !important;
		.cardTitle {
			border-radius: 25px 25px 0 0;
			color: white;
			font-size: 28px;
		}
		.input {
			font-size: 18px;
		}
	}
	.inputTitle {
		font-size: 18px;
	}
	.completedEducation {
		padding-top: 6px !important;
	}
	.photoRequirementsLink {
		font-size: 18px;
		text-decoration: none;
		text-transform: none;
		letter-spacing: 0px;
		&:hover {
			text-decoration: none;
		}
		span {
			line-height: 40px;
		}
	}
	.addChildButton {
		font-size: 18px;
		text-transform: none;
		letter-spacing: 0px;
	}
	.sendFormButton {
		font-size: 18px;
		letter-spacing: 0.5px;
	}
	@media screen and (max-width: 960px) {
		.mainTitle {
			width: 100%;
			text-align: center;
		}
		.card {
			margin-right: 0px !important;
			margin-left: 0px !important;
		}
	}
	@media screen and (max-width: 430px) {
		.cardTitle {
			padding-right: 20px !important;
			padding-left: 20px !important;
		}
	}
}
</style>