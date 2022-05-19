import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { isJSDocTypedefTag } from 'typescript';
import {jsPDF} from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-QRDownload-page',
  templateUrl: './QRDownload-page.component.html',
  styleUrls: ['./QRDownload-page.component.css']
})

export class QRDownloadComponent implements OnInit {


    ngOnInit(): void {
        
    }

    public PreviewQRCodeDiv(){
      let Data: any = document.getElementById('pdf');
      html2canvas(Data).then((canvas => {
        let fileWidth = Data.size;
        let fileHeight = (canvas.height * fileWidth) / canvas.width;
      const  FileURI = canvas.toDataURL('image/png');
      let pdf = new jsPDF('p', 'mm', 'a4');
      let position = 5;
    pdf.addImage(FileURI, 'png', 5, position, fileWidth, fileHeight);
    pdf.autoPrint; 
    pdf.output('dataurlnewwindow');
  }));
}

    public saveDiv(){
      let Data: any = document.getElementById('pdf');
      html2canvas(Data).then((canvas => {
        let fileWidth = Data.size;
        let fileHeight = (canvas.height * fileWidth) / canvas.width;
      const  FileURI = canvas.toDataURL('image/png');
      let pdf = new jsPDF('p', 'mm', 'a4');
      let position = 5;
    pdf.addImage(FileURI, 'png', 5, position, fileWidth, fileHeight);
    pdf.save('ProfileQRCode');  
    pdf.autoPrint;
   }));
  }
}
