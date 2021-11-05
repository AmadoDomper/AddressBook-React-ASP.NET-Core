import axios from "axios";
import { useHistory } from "react-router";
import ContactForm from "./ContactForm";
import { contactCreationDTO } from "./contacts.model";
import { urlContacts } from "../endpoints";

export default function CreateContact() {
const history = useHistory();

async function create(contact: contactCreationDTO){
    try{
        await axios.post(urlContacts, contact);
        history.push('/contacts');
    }catch(error){
        console.error(error);
    }
}

  return (
    <>
      <h3>Create Contact</h3>
      <ContactForm
        model={{ name: "", email: "", phone: "" }}
        onSubmit={async (value) => {
            await create(value);
        }}
      />
    </>
  );
}
