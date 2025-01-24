window.copyTextToClipboard = (text, element) => {
  navigator.clipboard.writeText(text)
    .then(() => {
      element.innerText = 'Copied!';
      element.classList.remove('invisible');
      setTimeout(() => {
        element.innerText = 'Copy';
        element.classList.add('invisible');
      }, 2000);
    });
}
window.registerBackdrop = (modalRef) => {
  document.addEventListener("click", event => {
    if (event.target === modalRef) {
      DotNet.invokeMethodAsync("Workshop.Library", "CloseBackdrop");
    }
  });
}