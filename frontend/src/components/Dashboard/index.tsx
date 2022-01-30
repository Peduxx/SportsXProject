import { Container } from "./styles";

interface DashboardProps {
  onOpenNewClientModal: () => void;
  setClientCPFFilter: any;
}

export function Dashboard({
  onOpenNewClientModal,
  setClientCPFFilter,
}: DashboardProps) {
  return (
    <Container>
      <input
        onChange={(event) => setClientCPFFilter(event.target.value)}
        placeholder="Procurar cliente pelo CPF"
        type="text"
        name="cpf"
      ></input>
      <button type="submit" onClick={onOpenNewClientModal}>
        Novo cliente
      </button>
    </Container>
  );
}
