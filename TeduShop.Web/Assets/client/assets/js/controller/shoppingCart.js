var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },
    registerEvent: function () {
            
        $('#frmOrderUser').validate({
            rules: {
                first_name : "required",
                    Email : {
                    required: true,
                        email:true
                },
                Phone: {
                    required: true, 
                        number : true
                },
                    Address : "required"
            },
            messages: {
                first_name: "Vui lòng nhập họ và tên",
                Email : {
                        required: "Vui lòng nhập Email",
                        email: "Định dạng Email không đúng"
                },
                Phone: {
                        required: "Vui lòng nhập số điện thoại",
                        number : "Định dạng số điện thoại không đúng"
                },
                Address: "Vui lòng nhập địa chỉ"
            }
        })

        $(".btnAddToCart").off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.addItem(productId);
        });

        $(".cart__remove").off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.deleteItem(productId);
        });

        $('.cart__qty-input').off('keyup').on('keyup', function () {
            var quantity = parseInt($(this).val());
            var price = parseFloat($(this).data('price'));
            var productId = parseInt($(this).data('id'));

            if (isNaN(quantity) == false) {
                var amount = quantity * price;
                $("#amount_" + productId).text(numeral(amount).format('0,0'));
            } else {
                $("#amount_" + productId).text(0);
            }

            $('#totalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
            $('#totalMoney').text(numeral(cart.getTotalOrder() * 1.1).format('0,0'));
            cart.UpdateCart();

        })

        $("#btnDeleteAll").off('click').on('click', function (e) {
            e.preventDefault();
            cart.DeleteAll();
        });

        $("#chkUserLoginInfo").off('click').on('click', function () {
            if ($(this).prop('checked')) {
                cart.getLoginUser();
            } else {
                $("#userFullName").val('')
                $("#userEmail").val('')
                $("#userPhone").val('')
                $("#userAddress").val('')
            }
            
        });

        $("#btnUpdateCart").off('click').on('click', function (e) {
            e.preventDefault();
            cart.UpdateCart();
        });

        $("#cartCheckout").off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frmOrderUser').valid();
            if (isValid) {
                cart.createUserOrder();
            }
        });
    },

    getLoginUser: function () {
        $.ajax({
            url: '/ShoppingCart/getLoginUser',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    var user = response.data;
                    $("#userFullName").val(user.FullName)
                    $("#userEmail").val(user.Email)
                    $("#userPhone").val(user.PhoneNumber)
                    $("#userAddress").val(user.Address)
                }
            }
        })
    },
    createUserOrder: function () {
        var order = {
            CustomerName : $("#userFullName").val(),
            CustomerAddress :$("#userAddress").val(),
            CustomerEmail: $("#userEmail").val(),
            CustomerMobile : $("#userPhone").val(),
            CustomerMessage : $("#userMessage").val(),
            PaymentMethod : '',
            PaymentStatus : true,
            Status: false
        }

        console.log();
        $.ajax({
            url: '/ShoppingCart/CreateUserOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (response) {
                if (response.status == true) {
                    cart.DeleteAll();
                    $('#Ordersuccess').css('visibility', 'visible');
                    $("#userFullName").val('')
                    $("#userEmail").val('')
                    $("#userPhone").val('')
                    $("#userAddress").val('')
                }
            }
        })
    },
    UpdateCart: function () {
        var cartList = [];
        $.each($('.cart__qty-input'), function (i, item) {
            if ($(item).val() == "") {
                $(item).val(0)
            }
            cartList.push({
                ProductId: $(item).data('id'),
                Quantity: $(item).val()
            })
        })
        $.ajax({
            url: '/ShoppingCart/Update',
            type: 'POST',
            dataType: 'json',
            data: {
                cartData: JSON.stringify(cartList)
            },
            success: function (response) {
                if (response.status == true) {
                    if (response.message != "") {
                        toastr.error(response.message,"Sản phẩm không đủ hàng")
                    }
                    cart.loadData();
                }
            }
        })
    },
    getTotalOrder: function () {
        var listTextBox = $('.cart__qty-input');
        var total = 0;
        $.each(listTextBox, function (i, item) {
            total += parseFloat($(item).data('price')) * parseInt($(item).val());
        })
        return total;
    },
    addItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/Add',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    toastr.success('Thêm vào giỏ hàng thành công!', 'Thông báo')
                } else {
                    toastr.error(response.message,"Thất bại")
                }
            }
        })
    },
    DeleteAll: function () {
        $.ajax({
            url: '/ShoppingCart/DeleteAll',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    cart.loadData();
                }
            }
        })
    },
    deleteItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    cart.loadData();
                }
            }
        })
    },
    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    var html = '';
                    var tplCart = $('#tplCart').html();
                    var data = res.data;
               
                    $.each(data, function (i, item) {
                        html += Mustache.render(tplCart, {
                            productId: item.ProductId,
                            productName: item.Product.Name,
                            productImage: item.Product.Image,
                            productPrice: item.Product.Price,
                            productAlias: item.Product.Alias,
                            productPriceF: numeral(item.Product.Price).format('0,0'),
                            productQuantity: item.Quantity,
                            Amount: numeral(item.Quantity * item.Product.Price).format('0,0'),
                        })
                    })


                    if (html == '') {
                        $("#cartBody").html("Không có sản phẩm nào trong giỏ hàng");
                    }
                    $("#cartBody").html(html);
                    cart.registerEvent();
                    $('#totalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
                    $('#totalMoney').text(numeral(cart.getTotalOrder()*1.1).format('0,0'));
                }
            }
        })
    }
}
cart.init();