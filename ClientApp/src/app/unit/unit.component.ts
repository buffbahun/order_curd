import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UnitService } from '../services/unit.service';

@Component({
  selector: 'app-unit',
  templateUrl: './unit.component.html',
  styleUrls: ['./unit.component.css']
})
export class UnitComponent implements OnInit {

  unit: FormGroup;
  list = [];
  editId = -1;

  constructor(public _service: UnitService) {
    this.unit = new FormGroup({
      Name: new FormControl('', Validators.required)
    });
    this.list = _service.getAll();
  }

  ngOnInit() {
  }

  addUnit() {
    if(this.editId >= 0 && this.unit.value.Name) {
      this.list[this.editId].Name = this.unit.value.Name;
      this._service.update(this.list[this.editId].id, this.unit.value);
    }
    else {
      this._service.add(this.list[this.list.push(this.unit.value)]);
      list = this._service.getAll();
    }
    this.unit.get("Name").setValue('');
    this.editId = -1;
  }

  deleteUnit(id) {
    this._service.delete(this.list[this.editId].id);
    this.list.splice(id, 1);
  }

  editUnit(id) {
    this.editId = id;
    this.unit.get('Name').setValue(this.list[id].Name);
  }
}
