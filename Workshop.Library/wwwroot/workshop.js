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
