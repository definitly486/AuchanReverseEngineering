.class public final Landroidx/lifecycle/AndroidViewModel_androidKt;
.super Ljava/lang/Object;
.source "AndroidViewModel.android.kt"


# direct methods
.method public static final getApplication(Landroidx/lifecycle/AndroidViewModel;)Landroid/app/Application;
    .locals 1

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 43
    invoke-virtual {p0}, Landroidx/lifecycle/AndroidViewModel;->getApplication()Landroid/app/Application;

    move-result-object p0

    return-object p0
.end method
