import { Header } from "./components/Header";
import { Dashboard } from "./components/Dashboard";
import { GlobalStyle } from "./styles/global";
import { ClientList } from "./components/ClientList";
import Modal from "react-modal";
import { useState } from "react";
import { NewClientModal } from "./components/NewClientModal";
import { EditClientModal } from "./components/EditClientModal";

Modal.setAppElement("#root");

export function App() {
  const [isNewClientModalOpen, setIsNewClientModalOpen] = useState(false);
  const [isEditClientModalOpen, setIsEditClientModalOpen] = useState(false);

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
      <NewClientModal
        isOpen={isNewClientModalOpen}
        onRequestClose={handleCloseNewClientModal}
      />
      <EditClientModal
        isOpen={isEditClientModalOpen}
        onRequestClose={handleCloseEditClientModal}
      />
      <Header />
      <Dashboard onOpenNewClientModal={handleOpenNewClientModal} />
      <ClientList onOpenEditClientModal={handleOpenEditClientModal} />
    </>
  );
}
