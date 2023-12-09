import {Component, OnDestroy} from '@angular/core';
import {CreatePostDtoModel} from "../../../../models/posts/create-post-dto.model";
import {PostService} from "../../../../services/post.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnDestroy {

  model: CreatePostDtoModel;

  private addPostSubscription?: Subscription
  constructor(private postService: PostService) {
    this.model = {
      Title: ' ',
      Description: ' ',
      Images: []
    };
  }
  onFormSubmit() {
    this.addPostSubscription = this.postService.addPost(this.model).subscribe({
      next: (response) => {
        console.log("Success");
      },
      error: (error) => {
        console.log("Error");
      }
    })
  }

  ngOnDestroy(): void {
    this.addPostSubscription?.unsubscribe();
  }
}
