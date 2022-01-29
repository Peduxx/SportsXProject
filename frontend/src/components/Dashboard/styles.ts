import styled from "styled-components";

export const Container = styled.div`
  width: 100%;
  padding: 1rem;
  display: flex;
  text-align: center;
  justify-content: center;
  padding: 5rem;

  input{
      width: 50%;
      padding: 12px 20px;
      margin: 8px;
      box-sizing: border-box;
      transition: width 0.4s ease-in-out;
    }

    button{
      font-size: 1rem;
      color: #fff;
      background: var(--blue-light);
      border: 0;
      padding: 0 2rem;
      border-radius: 0.25rem;
      height: 3rem;
      margin: 0.5rem;

      &:hover {
        filter: brightness(0.5);
    }
`;
