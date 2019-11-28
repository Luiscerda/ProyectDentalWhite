import { Paciente } from "./paciente";
import { Doctor } from "./doctor";

export class Cita {
    id:number;
    fecha:string;
    paciente:Paciente;
    identificacion_Paciente:string;
    doctor:Doctor;
    idDoctor:string;
}
