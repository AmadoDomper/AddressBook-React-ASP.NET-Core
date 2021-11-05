import IndexContacts from "./contacts/IndexContacts";

const routes = [
    {path: '/contacts', component: IndexContacts, exact: true},
    
    {path: '/', component: IndexContacts, exact: true},
    {path: '*', component: IndexContacts}
];

export default routes;