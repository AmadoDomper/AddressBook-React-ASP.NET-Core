import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { contactDTO } from "./contacts.model";
import GenericList from "../utils/GenericList";
import Button from "../utils/Buttons";
import { Link } from "react-router-dom";
import { urlContacts } from "../endpoints";
import customConfirm from "../utils/customConfirm";

export default function IndexContacts() {
  const [contacts, setContacts] = useState<contactDTO[]>();

  useEffect(() => {
    loadData();
  }, []);

  function loadData(){
    axios
      .get(urlContacts)
      .then((response: AxiosResponse<contactDTO[]>) => {
        setContacts(response.data);
        console.log(response.data);
      });
  }

  async function deleteGenre(id: number){
    try{
        await axios.delete(`${urlContacts}/${id}`);
        loadData();
    }catch(error){
      console.log(error);
    }
  }

  return (
    <>
      <h3>Contacts</h3>
      <Link className="btn btn-primary" to="/contacts/create">Create Contact</Link>
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
                <td>
                  <Link className="btn btn-success" to={`contacts/edit/${contact.id}`}>Edit</Link>
                  <Button className="btn btn-danger" onClick={() => customConfirm(() => deleteGenre(contact.id))}>Delete</Button>
                </td>
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
