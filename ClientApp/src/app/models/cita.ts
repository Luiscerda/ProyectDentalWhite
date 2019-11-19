import { Paciente } from "./paciente";
import { Doctor } from "./doctor";

export class Cita {
    id:number;
    fecha:string;
    paciente:Paciente;
    idPaciente:number;
    doctor:Doctor;
    idDoctor:number;
}
