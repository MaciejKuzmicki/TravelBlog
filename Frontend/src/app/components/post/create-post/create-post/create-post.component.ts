import { Component } from '@angular/core';
import {CreatePostDtoModel} from "../../../../models/posts/create-post-dto.model";

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent {

  model: CreatePostDtoModel;
  constructor() {
    this.model = {
      Title: ' ',
      Description: ' ',
      Images: []
    };
  }
  onFormSubmit() {
    console.log(this.model);
  }
}
