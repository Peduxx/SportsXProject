import { FormEvent, useState } from "react";
import Modal from "react-modal";
import { api } from "../../services/api";
import {
  Container,
  ClientClassificationContainer,
  RadioBox,
  TelephoneNumberBox,
} from "./styles";
import InputMask from "react-input-mask";

interface newClientModalProps {
  isOpen: boolean;
  onRequestClose: () => void;
}

export function NewClientModal({
  isOpen,
  onRequestClose,
}: newClientModalProps) {
  const [classification, setClassification] = useState(2);

  const [name, setName] = useState("");
  const [socialReason, setSocialReason] = useState("");
  const [email, setEmail] = useState("");
  const [CPF, setCPF] = useState("");
  const [CNPJ, setCNPJ] = useState("");
  const [CEP, setCEP] = useState("");
  const [number, setNumber] = useState("");

  const [phoneNumber, setphoneNumber] = useState([{}]);

  function handleAddNumber(event: FormEvent) {
    event.preventDefault();

    setphoneNumber(() => [{ number }]);
  }

  function handleCreateNewClient(event: FormEvent) {
    event.preventDefault();

    const data = {
      name,
      socialReason,
      email,
      CPF,
      CNPJ,
      CEP,
      phoneNumber,
      classification,
    };

    api.post("/Create", data).then((response) => alert(response.data));
  }

  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onRequestClose}
      overlayClassName="react-modal-overlay"
      className="react-modal-content"
    >
      <Container onSubmit={handleCreateNewClient}>
        <h2>Cadastrar cliente</h2>
        <input
          value={name}
          onChange={(event) => setName(event.target.value)}
          placeholder="Nome"
        />
        <input
          value={socialReason}
          onChange={(event) => setSocialReason(event.target.value)}
          placeholder="Razão Social"
        />
        <input
          value={email}
          onChange={(event) => setEmail(event.target.value)}
          placeholder="Email"
        />
        <InputMask
          value={CPF}
          onChange={(event) => setCPF(event.target.value)}
          mask="999.999.999-99"
          placeholder="CPF"
        />
        <InputMask
          value={CNPJ}
          onChange={(event) => setCNPJ(event.target.value)}
          mask="99.999.999/9999-99"
          placeholder="CNPJ"
        />
        <InputMask
          value={CEP}
          onChange={(event) => setCEP(event.target.value)}
          mask="99-999-999"
          placeholder="CEP"
        />
        <TelephoneNumberBox onSubmit={handleAddNumber}>
          <InputMask
            value={number}
            onChange={(event) => setNumber(event.target.value)}
            mask="(99)999999999"
            placeholder="Número de telefone"
          />
          <button type="submit" onClick={handleAddNumber}>
            Adicionar número de telefone
          </button>
        </TelephoneNumberBox>
        <ClientClassificationContainer>
          <RadioBox
            type="button"
            onClick={() => setClassification(1)}
            isActive={classification === 1}
          >
            Ativo
          </RadioBox>
          <RadioBox
            type="button"
            onClick={() => setClassification(2)}
            isActive={classification === 2}
          >
            Inativo
          </RadioBox>
          <RadioBox
            type="button"
            onClick={() => setClassification(3)}
            isActive={classification === 3}
          >
            Preferencial
          </RadioBox>
        </ClientClassificationContainer>
        <button type="submit">Confirmar</button>
      </Container>
    </Modal>
  );
}
