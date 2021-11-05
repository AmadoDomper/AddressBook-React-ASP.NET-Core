import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router";
import Loading from "../utils/Loading";
import ContactForm from "./ContactForm";
import { contactCreationDTO, contactDTO } from "./contacts.model";

export default function EditContact() {
  const { id }: any = useParams();
  const [contact, setContact] = useState<contactCreationDTO>();
  const history = useHistory();

  useEffect(() => {
    axios
      .get(`https://localhost:7211/api/contacts/${id}`)
      .then((response: AxiosResponse<contactDTO>) => {
        setContact(response.data);
        console.log(response.data);
      });
  },[id]);

  async function edit(contactToEdit: contactCreationDTO) {
    try {
      await axios.put(
        `https://localhost:7211/api/contacts/${id}`,
        contactToEdit
      );
      history.push("/contacts");
    } catch (error) {
      if (error) {
        console.error(error);
      }
    }
  }

  return (
    <>
      <h3>Edit Contact</h3>
      {contact ? 
        <ContactForm
          model={contact}
          onSubmit={async value => {
            await edit(value);
          }}
        ></ContactForm>
      : 
        <Loading />
      }
    </>
  );
}
