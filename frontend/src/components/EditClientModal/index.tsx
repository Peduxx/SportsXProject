import { FormEvent, useState } from "react";
import Modal from "react-modal";
import { api } from "../../services/api";
import { Container, ClientClassificationContainer, RadioBox } from "./styles";
import InputMask from "react-input-mask";
import { Client } from "../ClientList/types";

import { toast } from "react-toastify";

interface editClientModalProps {
  isOpen: boolean;
  onRequestClose: () => void;
  clientToEdit: Client;
}

export function EditClientModal({
  isOpen,
  onRequestClose,
  clientToEdit,
}: editClientModalProps) {
  const [classification, setClassification] = useState(2);

  const [name, setName] = useState("");
  const [socialReason, setSocialReason] = useState("");
  const [email, setEmail] = useState("");
  const [CEP, setCEP] = useState("");

  async function handleEditClient(event: FormEvent) {
    event.preventDefault();

    const data = {
      name: name || clientToEdit.name,
      socialReason: socialReason || clientToEdit.socialReason,
      email: email || clientToEdit.email,
      CEP: CEP || clientToEdit.cep,
      classification,
    };

    try {
      await api.put(`/Edit/?cpf=${clientToEdit.cpf}`, data);

      toast.success("Cliente editado com sucesso!");

      window.location.reload();
    } catch (err) {
      toast.error("Ocorreu um erro ao tentar editar o cliente!");
    }

    onRequestClose();
  }

  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onRequestClose}
      overlayClassName="react-modal-overlay"
      className="react-modal-content"
    >
      <Container onSubmit={handleEditClient}>
        <h2>Editar cliente</h2>
        <input
          defaultValue={clientToEdit.name}
          onChange={(event) => setName(event.target.value)}
          placeholder="Nome"
        />
        <input
          defaultValue={clientToEdit.socialReason}
          onChange={(event) => setSocialReason(event.target.value)}
          placeholder="Razão Social"
        />
        <input
          defaultValue={clientToEdit.email}
          onChange={(event) => setEmail(event.target.value)}
          placeholder="Email"
        />
        <InputMask
          defaultValue={clientToEdit.cep}
          onChange={(event) => setCEP(event.target.value)}
          mask="99-999-999"
          placeholder="CEP"
        />
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
