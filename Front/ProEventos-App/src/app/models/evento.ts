import { Palestrante } from './palestrante';
import { RedeSocial } from './rede-social';
import { Lote } from './lote';

export interface Evento {
  id: number;
  local: string;
  dataEvento?: Date;
  tema: string;
  qtdPessoas: number;
  imagemURL: string;
  telefone: string;
  email: string;
  lotes: Lote[];
  redesSociais: RedeSocial[];
  palestrantes: Palestrante[];
}
