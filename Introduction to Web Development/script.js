// script.js

const nav = document.querySelector('nav')
const hamburger = document.querySelector('.hamburger-icon')

const toggleMenu = () => {
  nav.classList.toggle('active')
  console.log('Menu toggled')
}

hamburger.addEventListener('click', toggleMenu)

document.querySelectorAll('nav a[href^="#"]').forEach(anchor => {
  anchor.addEventListener('click', e => {
    e.preventDefault()
    const targetId = anchor.getAttribute('href')
    document.querySelector(targetId).scrollIntoView({ behavior: 'smooth' })
    nav.classList.remove('active') // hide menu on selection (mobile)
    console.log(`Scrolled to ${targetId}`)
  })
})
