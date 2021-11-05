import { Form, Formik, FormikHelpers } from "formik";
import { contactCreationDTO } from "./contacts.model";
import TextField from "../forms/TextField";
import Button from "../utils/Buttons";
import { Link } from "react-router-dom";

export default function ContactForm(props: contactFormProps) {
  return (
    <Formik initialValues={props.model} onSubmit={props.onSubmit}>
      {(formikPropis) => (
        <Form>
          <TextField field="name" displayName="Name" />
          <TextField field="email" displayName="Email" />
          <TextField field="phone" displayName="Phone" />

          <Button disabled={formikPropis.isSubmitting} type="submit">
            Save Changes
          </Button>
          <Link className="btn btn-secondary" to="/contacts">
            Cancel
          </Link>
        </Form>
      )}
    </Formik>
  );
}

interface contactFormProps {
  model: contactCreationDTO;
  onSubmit(
    values: contactCreationDTO,
    action: FormikHelpers<contactCreationDTO>
  ): void;
}
