import { Component, OnInit } from '@angular/core';
import {PacienteService} from 'src/app/services/paciente.service';
import {Paciente} from 'src/app/models/paciente';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  constructor(private pacienteService:PacienteService) { }
  paciente:Paciente;

  ngOnInit() {
    this.paciente = { id: 0, tipoId: '', numeroCedula: '', nombres: '', apellidos: '', direccion: '', telefono: '', fechaNacimiento: '', edad:0 };
  }

  add() {
    this.pacienteService.addPaciente(this.paciente)
    .subscribe(paciente => {
    alert('Se agrego un nuevo paciente')
    });
  }

}
