import { isPlatformBrowser } from '@angular/common';
import { Component, ElementRef, Inject, OnInit, PLATFORM_ID, Renderer2 } from '@angular/core';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-google-analytics4',
  templateUrl: './google-analytics4.component.html',
  styleUrls: ['./google-analytics4.component.css']
})
export class GoogleAnalytics4Component implements OnInit {
  trackingCode = environment.googleAnalyticsTrackingCode;
  constructor( @Inject(PLATFORM_ID) private readonly platformId: Object,
  private readonly renderer: Renderer2,
  private readonly el: ElementRef,) { 

     // BROWSER
     if (isPlatformBrowser(this.platformId)) {
      const script = this.renderer.createElement('script') as HTMLScriptElement;
      script.src = `//www.googletagmanager.com/gtag/js?id=${this.trackingCode}`;
      script.async = true;
      this.renderer.appendChild(this.el.nativeElement, script);

      const script2 = this.renderer.createElement('script') as HTMLScriptElement;
      const scriptBody = this.renderer.createText(`
        window.dataLayer = window.dataLayer || [];
        function gtag() {
          dataLayer.push(arguments);
        }
        gtag('js', new Date());

        gtag('config', '${this.trackingCode}');
      `);
      this.renderer.appendChild(script2, scriptBody);
      this.renderer.appendChild(this.el.nativeElement, script2);
  }
  }
  ngOnInit(): void {
  }

}
