import { PhoneNumberContainer } from "./styles";
import { ClientNumber } from "../types";

const PhoneNumber = ({ numbers }: { numbers: ClientNumber[]}) => {

  return (
    <PhoneNumberContainer>
      {numbers.map((number, index) => (
        <p key={index}>{number.number}</p>
      ))}
    </PhoneNumberContainer>
  );
};

export default PhoneNumber;
