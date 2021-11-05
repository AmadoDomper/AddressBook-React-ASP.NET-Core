import IndexContacts from "./contacts/IndexContacts";
import CreateContact from "./contacts/CreateContact";

const routes = [
    {path: '/contacts', component: IndexContacts, exact: true},
    {path: '/contacts/create', component: CreateContact, exact: true},
    
    {path: '/', component: IndexContacts, exact: true},
    {path: '*', component: IndexContacts}
];

export default routes;