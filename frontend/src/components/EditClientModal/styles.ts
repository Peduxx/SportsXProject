import styled from "styled-components";

interface RadioBoxProps {
  isActive: boolean;
}

export const RadioBox = styled.button<RadioBoxProps>`
  height: 2.3rem;
  border: 1px solid #d7d7d7;
  border-radius: 0.3rem;

  background: ${(props) => (props.isActive ? "#3A4DC3" : "transparent")};
  display: flex;
  align-items: center;
  justify-content: center;

  color: ${(props) => (props.isActive ? "white" : "black")};

  &:hover {
    border-color: #aaa;
  }
`;

export const ClientClassificationContainer = styled.div`
  margin: 1rem 0;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
`;

export const Container = styled.form`
  h2 {
    font-family: sans-serif;

    color: var(--text-title);
    font-size: 1.5rem;
    margin-bottom: 2rem;
    gap: 0.5rem;
  }

  input {
    width: 100%;
    padding: 0 1.5rem;
    height: 2.3rem;
    border-radius: 0.5rem;

    border: 1px solid #d7d7d7;
    background-color: #e7e9ee;

    font-weight: 600;
    font-size: 1rem;

    &::placeholder {
      color: var(--text-body);
    }

    & + input {
      margin-top: 1rem;
    }
  }
  button[type="submit"] {
    width: 100%;
    padding: 0 1.5rem;
    height: 2.3rem;
    background: var(--blue);
    color: #fff;
    border-radius: 0.25rem;
    border: 0;
    font-size: 1rem;
    margin-top: 1.5rem;

    transition: filter 0.3s;

    &:hover {
      filter: brightness(0.3);
    }
`;
