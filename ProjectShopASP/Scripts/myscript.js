
$("#page_select").change(function () {
    $.ajax({
        url: "/Product/Category",
        data: { pageSiz: $(this).val() },
        success: function (reponse) {
            alert("send thanh cong")
        }
    })
});
/*
    Event click of update cart item
 */
$("#btnUpdate").off('click').on('click', function () {
    var listProduct = $('.txtQuantity');
    var cartList = [];
    $.each(listProduct, function (i, item) {
        cartList.push({
            Quantity: $(item).val(),
            Product: {
                id_product: $(item).data('id')
            }
        });
    });
    $.ajax({
        url: '/Cart/Update',
        data: { cartModel: JSON.stringify(cartList) },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/cart";
            }
        }
    });
});
/*
    Event click of delete cart item
 */
$(".btnDelete").off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        url: '/Cart/DeleteCartItem',
        data: { id: $(this).data('id')},
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = "/cart";
            }
        }
    });
});
/*
    Event click of delete header cart item
 */
$(".btnDeleteCartHeader").off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        url: '/Cart/DeleteCartItem',
        data: { id: $(this).data('id') },
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            window.location.reload();
        }
    });
});
/*
    Event click of check out
 */
$(".checkout_btn").off('click').on('click', function (e) {
    window.location.href = "/checkout";
});

var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response($.map(res.data, function (item) {
                            return {
                                label: item.image,
                                value: item.name_product
                            }
                        }));
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.value);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.value);
                return false;
            },
            select: function (event, ui) {
                /*
                var url = ui.item.id;
                if(url != '') {
                  location.href = '...' + url;
                }
                */
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li><div><img width='50' height='50' src='" + item.label + "'><span>" + item.value + "</span></div></li>").appendTo(ul);
            };
    }
}
common.init();



