import IndexContacts from "./contacts/IndexContacts";
import CreateContact from "./contacts/CreateContact";
import EditContact from "./contacts/EditContact";

const routes = [
    {path: '/contacts', component: IndexContacts, exact: true},
    {path: '/contacts/create', component: CreateContact},
    {path: '/contacts/edit/:id(\\d+)', component: EditContact},
    
    {path: '/', component: IndexContacts, exact: true},
    {path: '*', component: IndexContacts}
];

export default routes;