      function checknegative(str) {
          if (parseFloat(document.getElementById(str.id).value) < 0) {
              document.getElementById(str.id).value = "";
              document.getElementById(str.id).focus();
              alert('Negative Values Not allowed');
              return false;
          }
      }
         