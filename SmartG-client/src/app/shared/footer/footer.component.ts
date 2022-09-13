import { Component, OnInit } from '@angular/core';
import { ContentBlock } from 'src/app/_interfaces/content-block';
import { Widget } from 'src/app/_interfaces/widget';
import { ContentBlockService } from 'src/app/_services/content-block.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  widget:Widget;
  footerCopyText:ContentBlock;
  blocks:ContentBlock[];
  year= new Date().getFullYear();
  constructor(private widgetService:WidgetService,private blockService:ContentBlockService) { }

  ngOnInit(): void {
    this.getWidget();
  }
  getWidget(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget=res;
      this.getBlocks();
    })
  }

  getBlocks(){
    this.blockService.getContentBlocks(1,50).subscribe(res=>{
      this.blocks=res.result;
     // this.getWidgets();
     this.footerCopyText= this.blocks?.find(x=>x.contentBlockId===this.widget?.footerCopyrightBlock);
    // console.log(this.footerCopyText)
    })
  }

}
