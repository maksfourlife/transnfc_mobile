package md5d8daf588a4048364cfb2767249b9c4eb;


public class Entry
	extends md51558244f76c53b6aeda52c8a337f2c37.EntryRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("transnfc_v4.Droid.Renderers.Entry, transnfc_v4.Android", Entry.class, __md_methods);
	}


	public Entry (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == Entry.class)
			mono.android.TypeManager.Activate ("transnfc_v4.Droid.Renderers.Entry, transnfc_v4.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public Entry (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == Entry.class)
			mono.android.TypeManager.Activate ("transnfc_v4.Droid.Renderers.Entry, transnfc_v4.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public Entry (android.content.Context p0)
	{
		super (p0);
		if (getClass () == Entry.class)
			mono.android.TypeManager.Activate ("transnfc_v4.Droid.Renderers.Entry, transnfc_v4.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
