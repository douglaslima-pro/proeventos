import { Evento } from "./evento";
import { Palestrante } from "./palestrante";

export interface RedeSocial {
  id: number;
  nome: string;
  URL: string;
  eventoId: number;
  evento: Evento;
  palestranteId: number;
  palestrante: Palestrante;
}
