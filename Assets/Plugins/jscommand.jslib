mergeInto(LibraryManager.library, {
	downloadPDF: function() {
          const pdfUrl = 'assets/Design.pdf';
          const anchor = document.createElement('a');
          anchor.href = pdfUrl;
          anchor.download = 'What is Design.pdf';
          anchor.click(); },

        downloadPDF1: function() {
          const pdfUrl = 'assets/GraphicDesign.pdf';
          const anchor = document.createElement('a');
          anchor.href = pdfUrl;
          anchor.download = 'GraphicDesign.pdf';
          anchor.click(); },

        downloadPDF2: function() {
          const pdfUrl = 'assets/MotionDesign.pdf';
          const anchor = document.createElement('a');
          anchor.href = pdfUrl;
          anchor.download = 'MotionDesign.pdf';
          anchor.click(); },

        downloadPDF3: function() {
          const pdfUrl = 'assets/3dDesign.pdf';
          const anchor = document.createElement('a');
          anchor.href = pdfUrl;
          anchor.download = '3dDesign.pdf';
          anchor.click(); },

        downloadPDF4: function() {
          const pdfUrl = 'assets/UIUXDesign.pdf';
          const anchor = document.createElement('a');
          anchor.href = pdfUrl;
          anchor.download = 'UIUXDesign.pdf';
          anchor.click(); },

        downloadPDF5: function() {
          const pdfUrl = 'assets/GameDev.pdf';
          const anchor = document.createElement('a');
          anchor.href = pdfUrl;
          anchor.download = 'GameDev.pdf';
          anchor.click(); },

          });
