import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { contactDTO } from "./contacts.model";
import GenericList from "../utils/GenericList";

export default function IndexContacts() {
  const [contacts, setContacts] = useState<contactDTO[]>();

  useEffect(() => {
    axios
      .get("https://localhost:7211/api/contacts")
      .then((response: AxiosResponse<contactDTO[]>) => {
        setContacts(response.data);
        console.log(response.data);
      });
  }, []);

  return (
    <>
      <h3>Contacts</h3>
      <GenericList list={contacts}>
        <table className="table table-striped">
          <thead>
            <tr>
              <th>Actions</th>
              <th>Name</th>
              <th>Email</th>
              <th>Phone</th>
            </tr>
          </thead>
          <tbody>
            {contacts?.map((contact) => (
              <tr key={contact.id}>
                <td></td>
                <td>{contact.name}</td>
                <td>{contact.email}</td>
                <td>{contact.phone}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </GenericList>
    </>
  );
}
