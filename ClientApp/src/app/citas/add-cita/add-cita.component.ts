import { Component, OnInit } from '@angular/core';
import { HoraService } from 'src/app/services/hora.service';
import { Hora } from 'src/app/models/hora';
import { PacienteService } from 'src/app/services/paciente.service';
import { Paciente } from 'src/app/models/paciente';
import { DoctorService } from 'src/app/services/doctor.service';
import { Doctor } from 'src/app/models/doctor';
import { CitaService } from 'src/app/services/cita.service';
import { Cita } from 'src/app/models/cita';

@Component({
  selector: 'app-add-cita',
  templateUrl: './add-cita.component.html',
  styleUrls: ['./add-cita.component.css']
})
export class AddCitaComponent implements OnInit {

  constructor(
    private horaService : HoraService,
    private pacienteService: PacienteService,
    private doctorService: DoctorService,
    private citaService: CitaService
  ) { }
  cita:Cita;
  paciente:Paciente;
  horas:Hora[];
  pacientes:Paciente[];
  doctores:Doctor[];
  searchPaciente = '';
  searchDoctor = '';
  ngOnInit() {
    this.getAll();
    this.getAllPaciente();
    this.getAllDoctor();
    this.cita = {id:0, fecha: '', paciente: null, doctor:null, idPaciente:0, idDoctor:0}
  }

  getAll(){
    this.horaService.getAll().subscribe(horas=>this.horas=horas);
  }
  getAllPaciente(){
    this.pacienteService.getAll().subscribe(pacientes=>this.pacientes=pacientes);
    
  }
  getAllDoctor(){
    this.doctorService.getAll().subscribe(doctores=>this.doctores=doctores);
  }

  add() {
    this.cita.idPaciente = parseInt(this.searchPaciente);
    this.cita.idDoctor = parseInt(this.searchDoctor);
    this.citaService.addCita(this.cita)
    .subscribe(cita => {
    alert('Se agrego una nueva cita')
    });
  }

}
