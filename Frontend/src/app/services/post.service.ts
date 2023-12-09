import { Injectable } from '@angular/core';
import {CreatePostDtoModel} from "../models/posts/create-post-dto.model";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  addPost(model: CreatePostDtoModel): Observable<void> {
      let userId = "99bc1736-9bcb-46c7-ac36-67e9aa17cb12"; // HardCoded UserId, In case of any database changes, change this Id
      return this.http.post<void>('https://localhost:7269/api/User/99bc1736-9bcb-46c7-ac36-67e9aa17cb12/posts', model);
  }
}
