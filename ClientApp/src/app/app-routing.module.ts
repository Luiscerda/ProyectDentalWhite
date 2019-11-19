import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddComponent } from './pacientes/add/add.component';
import { ListComponent } from './pacientes/list/list.component';
import { EditComponent } from './pacientes/edit/edit.component';
import { DeleteComponent } from './pacientes/delete/delete.component';
import { AddCitaComponent } from './citas/add-cita/add-cita.component';
import { ListCitasComponent } from './citas/list-citas/list-citas.component';
import { EditCitasComponent } from './citas/edit-citas/edit-citas.component';
import { DeleteCitasComponent } from './citas/delete-citas/delete-citas.component';
import { AddHoraComponent } from './horas/add-hora/add-hora.component';
import { EditHoraComponent } from './horas/edit-hora/edit-hora.component';
import { DeleteHoraComponent } from './horas/delete-hora/delete-hora.component';
import { AddHistoriaComponent } from './historia/add-historia/add-historia.component';
import { ListHistoriaComponent } from './historia/list-historia/list-historia.component';
import { ViewHistoriasComponent } from './historia/view-historias/view-historias.component';
import { EditHistoriaComponent } from './historia/edit-historia/edit-historia.component';
import { AddTratamientoComponent } from './tratamientos/add-tratamiento/add-tratamiento.component';
import { EditTratamientosComponent } from './tratamientos/edit-tratamientos/edit-tratamientos.component';
import { DeleteTratamientosComponent } from './tratamientos/delete-tratamientos/delete-tratamientos.component';
import { AddDoctorComponent } from './empleados/doctores/add-doctor/add-doctor.component';
import { ListDoctorComponent } from './empleados/doctores/list-doctor/list-doctor.component';
import { EditDoctorComponent } from './empleados/doctores/edit-doctor/edit-doctor.component';
import { DeleteDoctorComponent } from './empleados/doctores/delete-doctor/delete-doctor.component';
import { AddEnfermeraComponent } from './empleados/enfermeras/add-enfermera/add-enfermera.component';
import { ListEnfermeraComponent } from './empleados/enfermeras/list-enfermera/list-enfermera.component';
import { AddPagosComponent } from './pagos/add-pagos/add-pagos.component';
import { EditEnfermeraComponent } from './empleados/enfermeras/edit-enfermera/edit-enfermera.component';
import { DeleteEnfermeraComponent } from './empleados/enfermeras/delete-enfermera/delete-enfermera.component';

const routes:Routes =[
  {
    path: 'pacientesAdd',
    component: AddComponent
  },
  {
    path: 'pacientesList',
    component: ListComponent
  },
  {
    path: 'pacienteEdit/:id',
    component: EditComponent
  },
  {
    path: 'pacienteDelete/:id',
    component: DeleteComponent
  },
  {
    path: 'citasAdd',
    component: AddCitaComponent
  },
  {
    path: 'registrarCitas',
    component: AddHoraComponent
  },
  {
    path: 'listCitas',
    component: ListCitasComponent
  },
  {
    path: 'editCita',
    component: EditCitasComponent
  },
  {
    path: 'deleteCita',
    component: DeleteCitasComponent
  },
  {
    path: 'editHora/:id',
    component: EditHoraComponent
  },
  {
    path: 'deleteHora/:id',
    component: DeleteHoraComponent
  },
  {
    path: 'addHistoria',
    component: AddHistoriaComponent
  },
  {
    path: 'listHistorias',
    component: ListHistoriaComponent
  },
  {
    path: 'viewHistorias',
    component: ViewHistoriasComponent
  },
  {
    path: 'editHistorias',
    component: EditHistoriaComponent
  },
  {
    path: 'addTratamiento',
    component: AddTratamientoComponent
  },
  {
    path: 'editTratamiento/:id',
    component: EditTratamientosComponent
  },
  {
    path: 'deleteTratamiento/:id',
    component:  DeleteTratamientosComponent 
  },
  {
    path: 'addOdontologo',
    component: AddDoctorComponent
  },
  {
    path: 'listOdontologos',
    component: ListDoctorComponent
  },
  {
    path: 'editOdontologo/:id',
    component: EditDoctorComponent
  },
  {
    path: 'deleteOdontologo/:id',
    component: DeleteDoctorComponent
  },
  {
    path: 'addEnfermera',
    component: AddEnfermeraComponent
  },
  {
    path: 'listEnfermeras',
    component: ListEnfermeraComponent
  },
  {
    path: 'addPago',
    component: AddPagosComponent
  },
  {
    path: 'editEnfermera',
    component: EditEnfermeraComponent
  },
  {
    path: 'deleteEnfermera',
    component: DeleteEnfermeraComponent
  }
]
@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]

})
export class AppRoutingModule { }
