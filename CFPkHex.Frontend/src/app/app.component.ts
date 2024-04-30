import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { FileSaverModule, FileSaverService } from 'ngx-filesaver';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ReactiveFormsModule, HttpClientModule, FileSaverModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'CFPkHex Web';
  form: FormGroup;
  file!: File;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private fileSaverService: FileSaverService) {
    this.form = this.formBuilder.group({
      savePokemonFile: this.formBuilder.control(null)
    })
  }

  uploadFile(event: any) {
    this.file = event.target.files[0];
  }

  submitForm() {
    let formData = new FormData();
    formData.append("SavePokemonFile", this.file);

    let endPoint = `${environment.apiUrl}/inventory/add-max-rare-candies`

    this.httpClient.post(endPoint, formData, {
      responseType: 'arraybuffer'
    }).subscribe({
      next: (response: any) => {
        this.fileSaverService.save(response, this.file.name);
      },
      error: (error) => {
        console.error(error);
      }
    })
  }
}
