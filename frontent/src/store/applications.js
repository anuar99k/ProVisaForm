import api from "../api/Applications";

export default {
    state: {
        applications: []
    },
    actions: {
        // getFlights(stateContext) {
        //     return new Promise((resolve, reject) => {
        //         api.getFlights(
        //             successResponse => {
        //                 stateContext.commit("setFlights", successResponse);
        //                 resolve(successResponse);
        //             },
        //             errorResponse => reject(errorResponse)
        //         );
        //     });
        // },
        // getFlight(stateContext, id) {
        //     return new Promise((resolve, reject) => {
        //         api.getFlight(
        //             successResponse => resolve(successResponse),
        //             errorResponse => reject(errorResponse),
        //             id
        //         );
        //     });
        // },
        // updateFlight(stateContext, data) {
        //     return new Promise((resolve, reject) => {
        //         api.updateFlight(
        //             successResponse => resolve(successResponse),
        //             errorResponse => reject(errorResponse),
        //             data.id, data.flight
        //         )
        //     });
        // },
        addApplication(stateContext, data) {
            return new Promise((resolve, reject) => {
                api.addApplication(
                    successResponse => {
                        //stateContext.commit('addApplication', successResponse);
                        resolve(successResponse);
                    },
                    errorResponse => reject(errorResponse),
                    data
                )
            });
        }
        // deleteFlight(stateContext, id) {
        //     return new Promise((resolve, reject) => {
        //         api.deleteFlight(
        //             successResponse => {
        //                 stateContext.commit('deleteFlight', id);
        //                 resolve(successResponse);
        //             },
        //             errorResponse => reject(errorResponse),
        //             id
        //         )
        //     });
        // },
    },
    mutations: {
        // setFlights(state, data) {
        //     state.flights = data;
        // },
        addApplication(state, data) {
            state.applications.push(data);
        },
        // deleteFlight(state, id) {
        //     state.flights = state.flights.filter(flight => flight.flightId != id);
        // }
    },
    getters: {
        // getFlights(state) {
        //     return state.flights;
        // }
    }
}