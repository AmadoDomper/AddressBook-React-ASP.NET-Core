import * as Yup from "yup";

function configureValidations() {
  Yup.addMethod(Yup.string, "firstLetterUpperCase", function () {
    return this.test(
      "first-letter-uppercase",
      "First letter must be uppercase",
      function (value) {
        if (value && value.length > 0) {
          const firstLetter = value.substring(0, 1);
          return firstLetter === firstLetter.toUpperCase();
        }
        return true;
      }
    );
  });

  Yup.addMethod(Yup.string, "phone", function () {
    return this.test(
      "phone",
      "Phone number is not valid",
      function (value) {
        if (value && value.length > 0) {
          const phoneRegExp = /^(\+?\d{0,4})?\s?-?\s?(\(?\d{3}\)?)\s?-?\s?(\(?\d{3}\)?)\s?-?\s?(\(?\d{3,4}\)?)?$/;
          return phoneRegExp.test(value);
        }
        return true;
      }
    );
  });

  Yup.addMethod(Yup.string, "name", function () {
    return this.test(
      "name",
      "Name contains invalid characters",
      function (value) {
        if (value && value.length > 0) {
          const nameRegExp = /^[a-zA-Z\s]*$/;
          return nameRegExp.test(value);
        }
        return true;
      }
    );
  });
}

export default configureValidations;