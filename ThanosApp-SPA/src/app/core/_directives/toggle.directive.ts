import { Directive, ElementRef } from '@angular/core';

@Directive({
  exportAs: 'toggle',
  selector: 'toggle,[appToggle]',
})
export class ToggleDirective {
  constructor(el: ElementRef) {
    console.log('element' + el);
    console.log('Test click directive') ;
      //document.querySelector()
    //$('body').toggleClass('open-sidebar-menu');
  }
}
