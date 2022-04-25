import { RedeSocial } from "./RedeSocial";
import { Evento} from "./Evento";

export interface Palestrante {
  Id:number;
  Nome: string;
  MiniCurriculo:string;
  ImageUrl:string;
  Telefone:string;
  Email:string;
  RedesSociais:RedeSocial[];
  PalestrantesEventos:Evento[];
}
