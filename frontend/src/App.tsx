import { Header } from "./components/Header";
import { Dashboard } from "./components/Dashboard";
import { GlobalStyle } from "./styles/global";
import { ClientList } from "./components/ClientList";
import Modal from "react-modal";
import { useEffect, useState } from "react";
import { NewClientModal } from "./components/NewClientModal";
import { EditClientModal } from "./components/EditClientModal";

import { ToastContainer } from "react-toastify";

import { api } from "./services/api";
import { Client } from "./components/ClientList/types";

import "react-toastify/dist/ReactToastify.css";

Modal.setAppElement("#root");

export function App() {
  const [isNewClientModalOpen, setIsNewClientModalOpen] = useState(false);
  const [isEditClientModalOpen, setIsEditClientModalOpen] = useState(false);
  const [clientToEdit, setClientToEdit] = useState<Client>({
    classification: 0,
    cpf: "",
    cnpj: "",
    email: "",
    cep: "",
    socialReason: "",
    id: 0,
    name: "",
    phoneNumber: [],
  });

  const [clients, setClients] = useState<Client[]>([]);
  const [clientCPFFilter, setClientCPFFilter] = useState("");

  useEffect(() => {
    api.get("/").then((response) => setClients(response.data));
  }, []);

  function handleOpenNewClientModal() {
    setIsNewClientModalOpen(true);
  }

  function handleCloseNewClientModal() {
    setIsNewClientModalOpen(false);
  }

  function handleOpenEditClientModal() {
    setIsEditClientModalOpen(true);
  }

  function handleCloseEditClientModal() {
    setIsEditClientModalOpen(false);
  }
  return (
    <>
      <GlobalStyle />

      <ToastContainer autoClose={3000} />

      <NewClientModal
        isOpen={isNewClientModalOpen}
        onRequestClose={handleCloseNewClientModal}
      />
      <EditClientModal
        isOpen={isEditClientModalOpen}
        onRequestClose={handleCloseEditClientModal}
        clientToEdit={clientToEdit}
      />
      <Header />

      <Dashboard
        onOpenNewClientModal={handleOpenNewClientModal}
        setClientCPFFilter={setClientCPFFilter}
      />

      <ClientList
        onOpenEditClientModal={handleOpenEditClientModal}
        clients={clients}
        clientCPFFilter={clientCPFFilter}
        setClientToEdit={setClientToEdit}
      />
    </>
  );
}
