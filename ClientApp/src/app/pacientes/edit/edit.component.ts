import { Component, OnInit } from '@angular/core';
import {PacienteService} from 'src/app/services/paciente.service';
import {Paciente} from 'src/app/models/paciente';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  paciente:Paciente;
  constructor(
    private route : ActivatedRoute,
    private pacienteService: PacienteService,
    private location : Location
  ) { }

  ngOnInit() {
    this.get();
  }

  get(): void{
    const id = +this.route.snapshot.paramMap.get('identificacion_Paciente');
    this.pacienteService.get(id).subscribe(paciente => this.paciente = paciente);
  }

  goBack(): void{
    this.location.back();
  }

  update(): void{
    this.pacienteService.update(this.paciente).subscribe(() => this.goBack());
  }

}
