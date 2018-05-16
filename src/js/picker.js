import styles from 'huebee/dist/huebee.css';
let Huebee = require('huebee/dist/huebee.pkgd.js');

class Picker {
  constructor(container, options) {
    this._container = container;
    this._options = options;
    this._huebee = new Huebee(container, options);
  }

  clear(id) {
    var container = document.querySelector('.huebee');
    if(container) {
      container.remove();
      var input = document.getElementById(id);
      if(input) {      
        this._huebee = new Huebee(input, this._options);
        input.style = '';
      }    
    }
  }
}

export default Picker;

export {
  Picker
}