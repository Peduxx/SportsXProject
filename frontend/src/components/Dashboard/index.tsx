import { useEffect, useState } from "react";
import { api } from "../../services/api";
import { ClientList } from "../ClientList";
import { Container } from "./styles";

interface DashboardProps {
  onOpenNewClientModal: () => void;
}

export function Dashboard({ onOpenNewClientModal }: DashboardProps) {
  const [clientCPF, setClientCPF] = useState("");
  const [client, setClient] = useState({});

  function handleGetClient() {
    api
      .get(`/Get?cpf=${clientCPF}`)
      .then((response) => setClient(response.data));
  }

  console.log(client);

  return (
    <Container onSubmit={handleGetClient}>
      <input
        value={clientCPF}
        onChange={(event) => setClientCPF(event.target.value)}
        placeholder="Procurar cliente pelo CPF"
        type="text"
        name="cpf"
      ></input>
      <button type="submit" onClick={handleGetClient}>
        Procurar
      </button>
      <button type="submit" onClick={onOpenNewClientModal}>
        Novo cliente
      </button>
    </Container>
  );
}
