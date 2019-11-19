import { Component, OnInit } from '@angular/core';
import {PacienteService} from 'src/app/services/paciente.service';
import {Paciente} from 'src/app/models/paciente';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  pacientes: Paciente[];
  constructor(private pacienteService:PacienteService) { }
  filterPaciente = '';
  ngOnInit() {
    this.getAll();
  }

  getAll(){
    this.pacienteService.getAll().subscribe(pacientes=>this.pacientes=pacientes);
  }

}
