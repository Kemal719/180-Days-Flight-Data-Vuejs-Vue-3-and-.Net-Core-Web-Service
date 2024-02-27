import { createStore } from "vuex";

export default createStore({
  state: {
    searchValue:'Kemal'
  },
  mutations: {
    setSearchValue(state, value ){
        state.searchValue = value;
    }
  },
  getters: { getSearchValue(state) {
    return state.searchValue;
  }},
  actions: { setSearchValue( { commit }, data ){
    commit( 'setSearchValue', data );
}},
  modules: {},
});

