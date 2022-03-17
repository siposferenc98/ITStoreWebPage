function CarouselStart()
{
    $('.carousel').carousel('cycle');
}

/*var ITProjectCsharp = ITProjectCsharp || {};
ITProjectCsharp.GetActivePicture = function (dotNetRef)
{
    let carousel = document.getElementById("carouselOnlySlides");
    carousel.addEventListener('slid.bs.carousel', function (event)
    {
        console.log(event.relatedTarget);
        dotNetRef.invokeMethodAsync("ChangeActiveId", event.relatedTarget.id);

    });
}*/